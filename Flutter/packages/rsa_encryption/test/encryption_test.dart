import 'package:flutter_test/flutter_test.dart';
import 'package:rsa_encryption/rsa_encryption.dart';



void main(){



}

Future<void> _test(String data) async {
  final encrypted= RSAEncryption.encryptedBase64(data);
  final decrypted= RSAEncryption.decryptBase64(encrypted);
  expect(data, decrypted);
}

